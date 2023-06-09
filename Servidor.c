#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int contador;
int port=9035;
int sockets[100];
char tiro[2];
char parada[2];

//Estructura de datos para almacenar 50 conectados
typedef struct{
	char nombre[20];
	int socket;
	
}Conectado;

typedef struct{
	Conectado conectados[50];
	int num;
}ListaConectados;

typedef struct{
	int idP;
	char host[20];
	char invitado[20];
	int s_host;
	int s_invitado;
	int form_host;
	int form_invitado;
}Partida;

ListaConectados milista;
char conectados[50];
Partida miPartida[100];

void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
			
	char peticion[512];
	char respuesta[512];
	char respuesta1[512];
	int ret;
	int numForm;
	int idPartida;
	int idSQL;
	char resp[20];
	char notifi[200];
	char notifi2[200];

	char frase[100];
	int sock_listen;
	struct sockaddr_in serv_adr;
	
	int i;
	int terminar=0;
	char password[20], stadio[20];
	int s1, s2;
	
	//Creamos conexion sql (ya est� dentro del while pero lo volvemos a hacer para la lista de conectados)
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
		
		while(!terminar){
			char username[20];
			char username2[20];
			
			// Ahora recibimos su peticion
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibida una peticion\n");
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			MYSQL *conn;
			//Escribimos la peticion en la consola
			
			printf("La peticion es: %s\n",peticion);
			char *p = strtok(peticion, "/");
			int codigo =  atoi (p);
			printf("%d\n", codigo);
			
			int i;
			i=0;
			
			if (codigo ==0) //peticion de desconexi?n
			{
				int res = EliminarConectado(username, &milista);
				if (res==-1)
					printf("Error al eliminar usuario\n");
				else
					printf("Usuario eliminado correctamente\n");
				
				terminar = 1;
				
				DameConectados(&milista, notifi);
				
				sprintf(notifi2, "6/%s", notifi);
				
				for(int i = 0; i<milista.num;i++){
					write(milista.conectados[i].socket,notifi2,sizeof(notifi2));
				}
								
			}
						
			else if(codigo == 1) //Peticion de conexion
			{
				p = strtok( NULL, "/");
				strcpy (username, p);
				p = strtok (NULL, "/");
				strcpy(password, p);
				printf ("Codigo: %d, Username: %s, password: %s\n", codigo, username, password);
				
				int err;
				char consulta[2048];
				MYSQL_RES *resultado;
				MYSQL_ROW row;
				
				//Creamos una conexion al servidor MYSQL 
				conn = mysql_init(NULL);
				if (conn==NULL) {
					printf ("Error al crear la conexion: %u %s\n", 
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				//inicializar la conexion
				conn = mysql_real_connect (conn, "localhost","root", "mysql", "game",0, NULL, 0);
				if (conn==NULL) {
					printf ("Error al inicializar la conexi�n: %u %s\n", 
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				sprintf(consulta, "SELECT JUGADOR.USERNAME, JUGADOR.PASSWORD FROM JUGADOR WHERE (JUGADOR.USERNAME='%s' AND JUGADOR.PASSWORD='%s')", username, password);
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf ("Error al consultar datos \n");
					exit(1);
				}
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				
				if (row[0] == NULL){
					printf("No hay datos\n");
					strcpy(respuesta1, "1/NO");
					write (sock_conn, respuesta1, strlen(respuesta1));
				}
				else
				{	
					strcpy(respuesta1, "1/SI");
					write (sock_conn, respuesta1, strlen(respuesta1));
					
					//A�adimos al usuario a la Lista de Conectados
					int res = AnadirConectado(username, sock_conn, &milista);
					if (res==-1)
						printf("La lista est� llena\n");
					else
						printf("A�adido correctamente\n");
					
					int socket= DameSocket(&milista, username);
					if (socket!=-1)
						printf("'%s' -> %d\n", username, socket);
					else
						printf("Ese usuario no existe\n");
										
					int j;
					char notifi[200];
					char notifi2[200];
					DameConectados(&milista, notifi);
					sprintf(notifi2, "6/%s", notifi);
					
					//bucle para mandar notificacion
					for(j=0;j<milista.num;j++){
						write(sockets[j], notifi2, strlen(notifi2));
						
					}
					printf("Resultado:'%s'\n", notifi);
					printf("Resultado:'%s'\n", notifi2);
					
				}
				
			}
			
			else if (codigo == 2) //Peticion de registro
			{
				p = strtok( NULL, "/");
				strcpy (username, p);
				p = strtok (NULL, "/");
				strcpy(password, p);
				printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, username, password);
				MYSQL *conn;
				int err;
				MYSQL_RES *resultado;
				MYSQL_ROW row;
				char consulta [100];
				conn = mysql_init(NULL);
				if (conn == NULL) {
					printf("Error al crear la conexion: %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				conn = mysql_real_connect (conn,  "localhost","root", "mysql", "game", 0, NULL, 0);
				if (conn == NULL) {
					printf("Error al inicializar la conexion: %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				
				
				sprintf (respuesta, "SELECT JUGADOR.ID FROM JUGADOR WHERE JUGADOR.ID = (SELECT MAX(JUGADOR.ID) FROM JUGADOR)");
				err=mysql_query (conn, respuesta);
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					
					exit (1);
				}
				resultado = mysql_store_result(conn);
				row = mysql_fetch_row (resultado);
				idSQL = atoi(row[0]);
				idSQL = idSQL + 1;
				sprintf(consulta, "INSERT INTO JUGADOR VALUES ('%d','%s','%s')",idSQL, username, password); //Insertamos el id, el username y el password para a�adirlos a la base de datos.
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf("Error al consultar datos de la base: %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result (conn);
				write(sock_conn, "9/",strlen("9/"));
				mysql_close (conn);
			}
			
			else if(codigo==3){ //�En que partidas ha participado el "Playertwo"?
				p = strtok( NULL, "/");
				strcpy (username, p);
				printf("Codigo: %d, Username: %s\n", codigo, username);
				int resu = PartidasPlayerTwo(username, conn, respuesta); //provar de borrar el bin
				char respuesta2[512];
				if (resu==-1)
					strcpy(respuesta2, "3/No hay resultados");
				else
					sprintf(respuesta2, "3/%s", respuesta);
				//sprintf(respuesta,"%d", resu);
				write(sock_conn, respuesta2, strlen(respuesta2));
				strcpy(respuesta, "");
			}
			
			else if (codigo ==4){ //�Dime los jugadores que han jugado en un estadio?
				p = strtok( NULL, "/");
				strcpy (stadio, p);
				printf ("Codigo: %d, Estadio: %s\n", codigo, stadio);
				int resu = JugadoresEnEstadio(stadio, conn, respuesta);
				if (resu==-1)
					strcpy(respuesta, "No hay resultados");
				//sprintf (respuesta,"%c", resu);
				write (sock_conn, respuesta, strlen(respuesta));
				strcpy(respuesta, "");
			}
			
			else if (codigo ==5){ //�Dime que jugadores han marcado dos o mas goles y en que estadio lo han hecho?
				sprintf (respuesta,"%c","%c%", JugadoresEnEstadio(stadio, conn));
				write (sock_conn, respuesta, strlen(respuesta));
			}
			
			else if (codigo == 7){ // Invitar a otro jugador
				printf("Mensaje\n");
				p = strtok (NULL, "/");
				strcpy(username2, p);
				sprintf (respuesta,"7/%s-%s",username,username2);
				printf("%s\n",respuesta);
				write (DameSocket(&milista, username2), respuesta, strlen(respuesta));
			}
			
			else if(codigo == 8) //Respuesta invitacion a partida en el caso del host
			{
				p = strtok (NULL, "/");
				strcpy(username2, p);
				
				p = strtok (NULL, "/");
				strcpy(resp, p);
				
				p = strtok (NULL, "/");
				strcpy(resp, p);
				if(strcmp(resp,"SI")==0)
				{
					int idP = AnadirPartida (miPartida,username,username2,DameSocket(&milista, username),DameSocket(&milista, username2));
					sprintf (respuesta,"8/%s-%s-%s-%d",username2,username,resp,idP);
					printf("%s\n",respuesta);
					write (DameSocket(&milista, username), respuesta, strlen(respuesta));
					sprintf (respuesta,"11/%s-%s-%s-%d",username,username2,resp,idP);
					write (DameSocket(&milista, username2), respuesta, strlen(respuesta));
				}
				
				else
				{
					sprintf (respuesta,"8/%s-%s-%s",username2,username,resp);
					write (DameSocket(&milista, username), respuesta, strlen(respuesta));
				}
				
			}
			
			else if(codigo == 11) //Respuesta de la invitacion en el caso de ser el invitado
			{
				p = strtok (NULL, "/");
				strcpy(numForm, p);
				printf(numForm);
				p = strtok (NULL, "/");
				strcpy(username, p);
				p = strtok (NULL, "/");
				strcpy(idPartida, p);
				
				AnadirFormEnPartida(miPartida,username,numForm,idPartida);
				
				p = strtok (NULL, "/");
				strcpy(username2, p);
				p = strtok (NULL, "/");
				strcpy(resp, p);
				if(strcmp(resp,"SI")==0)
				{
					int idP = AnadirPartida (miPartida,username,username2,DameSocket(&milista, username),DameSocket(&milista, username2));
					sprintf (respuesta,"11/%s-%s-%s-%d",username2,username,resp,idP);
					write (DameSocket(&milista, username), respuesta, strlen(respuesta));
					sprintf (respuesta,"11/%s-%s-%s-%d",username,username2,resp,idP);
					write (DameSocket(&milista, username2), respuesta, strlen(respuesta));
				}
				
				else
				{
					sprintf (respuesta,"11/%s-%s-%s",username2,username,resp);
					write (DameSocket(&milista, username), respuesta, strlen(respuesta));
				}
				
			}
			
			else if(codigo ==10)
			{ 
				p = strtok (NULL, "/");
				strcpy(numForm, p);
				p = strtok (NULL, "/");
				strcpy(idPartida, p);
				p = strtok (NULL, "/");
				strcpy(frase, p);
				
				sprintf (respuesta,"9/%s",frase);
				write (DameSocket(&milista, username2), respuesta, strlen(respuesta));
			}
			
			else if (codigo == 12) //Darse de baja
			{
				p = strtok( NULL, "/");
				strcpy (username, p);
				p = strtok (NULL, "/");
				strcpy(password, p);
				printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, username, password);
				MYSQL *conn;
				int err;
				MYSQL_RES *resultado;
				MYSQL_ROW row;
				char consulta [100];
				conn = mysql_init(NULL);
				if (conn == NULL) {
					printf("Error al crear la conexion: %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				conn = mysql_real_connect (conn,  "localhost","root", "mysql", "game", 0, NULL, 0);
				if (conn == NULL) {
					printf("Error al inicializar la conexion: %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
								
				sprintf(consulta, "DELETE FROM JUGADOR WHERE USERNAME = '%s' AND PASSWORD = '%s'", username, password);
				
				err=mysql_query (conn, consulta);
				if (err!=0) {
					printf("Error al consultar datos de la base: %u %s\n",
						   mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				resultado = mysql_store_result (conn);
				write(sock_conn, "12/",strlen("12/"));
				mysql_close (conn);
			}
			
			if ((codigo == 3)||(codigo == 4)||(codigo == 5))
				
			{
				
				pthread_mutex_lock( &mutex ); //que no interrumpa
				contador =  contador + 1;
				pthread_mutex_unlock( &mutex ); //ya puede interrumpir
				
				char notifi[50];
				sprintf(notifi,"%d", contador);
				int j;
				int sockets[100];
				for(j=0;j<i;j++){
					write(sockets[j],notifi,strlen(notifi));
				}
				
			}
			
			else if (codigo == 15) //Chat global
			{
				
				//s2 = DameSocket(&milista, username2);
				p = strtok (NULL, "/");
				char nombre[20];
				strcpy(nombre, p);
				p = strtok (NULL, "/");
				char mensaje[200];
				strcpy(mensaje, p);
				sprintf (respuesta,"15/%s/%s/",nombre, mensaje);
				
				for(int i=0; i<milista.num; i++){
					if(milista.conectados[i].socket!=sock_conn)
						write (milista.conectados[i].socket, respuesta, sizeof(respuesta));
					
				}
				
			}
			
			else if (codigo == 30){ //Seleccion de los juagadores
				p = strtok (NULL, "/");
				char rol[2];
				strcpy(rol, p); //Separamos para diferenciar entre el jugador y el portero
				
				
				
				if(strcmp(rol,"x")==0) //jugador
				{
					p = strtok (NULL, "/");
					strcpy(tiro, p);
				}
				
				else{
					p = strtok (NULL, "/"); //portero
					strcpy(parada, p);
				}	
				
				if( (strlen(tiro) > 0 && strlen(parada) > 0)){ //os aseguramos que los dos hayan elegido el lado de la porteria
					
					if(strcmp(tiro, parada)==0){ //si coinciden el portero para la pelota
					sprintf(respuesta, "30/parada");
					printf("Ha sido: %s\n" ,respuesta);
					write (DameSocket(&milista, username), respuesta, sizeof(respuesta));
					write (DameSocket(&milista, username2), respuesta, sizeof(respuesta));
					
					memset(tiro, '\0', sizeof(tiro));
					memset(parada, '\0', sizeof(parada));
					
					}
				
					else{ //En caso contrario es gol
					sprintf(respuesta, "30/gol");
					printf("Ha sido: %s\n" ,respuesta);
					write (DameSocket(&milista, username), respuesta, sizeof(respuesta));
					write (DameSocket(&milista, username2), respuesta, sizeof(respuesta));
					
					memset(tiro, '\0', sizeof(tiro));
					memset(parada, '\0', sizeof(parada));
					}
				}
			}
		}		
}

int AnadirConectado(char nombre[20], int socket, ListaConectados *lista)
{
	
	if (lista->num==100)
		return -1;
	else{
		//Al modificar la lista de conectados necesitamos garantizar el acceso excluyente
		pthread_mutex_lock(&mutex);
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		pthread_mutex_unlock(&mutex);
		return 0;
	}
	
}

int DameSocket(ListaConectados *lista, char nombre[20])
{
	int i = 0;
	int j = 0;
	int encontrado = 0;
	while (encontrado == 0 && lista->num != j){
		if(strcmp(lista->conectados[j].nombre,nombre) == 0)
			encontrado = 1;
		else
			j = j + 1;
	}
	if (encontrado == 0)
		return -1;
	else
		printf("socket: %d\n",lista->conectados[i].socket);
		return lista->conectados[j].socket;
}
int DamePosicion(char nombre[20],ListaConectados *lista)
{
	
	int i = 0;
	int encontrado = 0;
	while ((encontrado == 0) && (lista->num != i)){
		if(strcmp(lista->conectados[i].nombre,nombre) == 0)
			encontrado = 1;
		else
			i++;
	}
	if (encontrado == 0)
		return -1;
	else
		return i;
}
int EliminarConectado(char nombre[20],ListaConectados *lista)
{
	int pos = DamePosicion(nombre,lista);
	
	if(pos == -1)
		return -1;
	else{
		int i;
		for(i = pos; i < lista -> num; i++){
			lista->conectados[i] = lista->conectados[i+1];
			lista->num = (lista->num)-1;
			
		}
		return 0;
		
	}
}
void DameConectados(ListaConectados *milista, char resultado[200])
{
	int i;
	for(i = 0; i != milista->num; i++){
		sprintf(resultado,"%s%s/",resultado,milista->conectados[i].nombre);
	}
}

int AnadirPartida(Partida miPartida[],char nombreHost[20],char nombreInv[20], int socketH,int socketI)
{
	int i =0;
	int terminado=0;
	while(i<100 && terminado==0)
	{
		if(miPartida[i].idP == NULL)
		{
			miPartida[i].idP = i;
			strcpy(miPartida[i].host, nombreHost);
			
			miPartida[i].s_host = socketH;
			strcpy(miPartida[i].invitado, nombreInv);
			miPartida[i].s_invitado = socketI;
			terminado =1;
			
		}
		else
		{
			i++;
		}
	}
	if(terminado == 0)
	{
		return -1;
	}
	else
	{
		return i;
	}
} 

void AnadirFormEnPartida(Partida miPartida[], char nombre[20], int numForm,int idP)
{
	int i =0;
	int terminado =0;
	while(i<100 && terminado==0)
	{
		if(strcmp(miPartida[i].host,nombre)==0 && strcmp(miPartida[i].idP,idP)==0)
		{
			miPartida[i].form_host=numForm;
			terminado=1;
		}
		else if(strcmp(miPartida[i].invitado,nombre)==0  && strcmp(miPartida[i].idP,idP)==0)
		{
			miPartida[i].form_invitado=numForm;
			terminado =1;
		}
		else
		{
			i++;
		}
	}
	
}
	int main(int argc, char *argv[])
	{
		int sock_conn, sock_listen;
		struct sockaddr_in serv_adr;
		
		// INICIALITZACIONS
		// Obrim el socket
		if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
			printf("Error creant socket");
		// Fem el bind al port
		memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
		serv_adr.sin_family = AF_INET;
		// asocia el socket a cualquiera de las IP de la m?quina. 
		//htonl formatea el numero que recibe al formato necesario
		serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
		// escucharemos en el port 9050
		serv_adr.sin_port = htons(port);
		if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
			printf ("Error al bind");
		//La cola de peticiones pendientes no podr? ser superior a 4
		if (listen(sock_listen, 4) < 0)
			printf("Error en el Listen");
		
		contador = 0;
		int i;
		pthread_t thread;
		i=0;
		//Atenderemos 5 peticiones
		for (;;){
			
			printf ("Escuchando\n");
			sock_conn = accept(sock_listen, NULL, NULL);
			printf ("He recibido conexion\n");
			sockets[i]= sock_conn;
		
			//Crear thread y decirle lo que tiene que hacer
			
			pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
			
			i=i+1;
			
		}
	}

//conval toma el valor de con cuando llama a la funcion
int PartidasPlayerTwo(char username[20], MYSQL *connval, char respuesta[512]) {
	int err;
	char consulta[2048];
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	
	printf("Dame el jugador\n");
	sprintf(consulta,"SELECT PARTIDA.ID FROM(JUGADOR, PARTIDA, PUNTUACIONES) WHERE JUGADOR.USERNAME='%s' AND JUGADOR.ID=PUNTUACIONES.JUGADOR_ID AND PARTIDA.ID=PUNTUACIONES.PARTIDA_ID;", username);
	printf("%s \n", consulta);
	
	err = mysql_query(connval, consulta);
	
	if (err != 0) {
		printf("Error en la consulta\n");
		mysql_errno(connval), mysql_error(connval);
		return -1;
	}
	
	resultado = mysql_store_result(connval);
	row = mysql_fetch_row(resultado);
	// Recorrer todas las filas del resultado
	int id_partida;
	int i = 0;
	while (row!=NULL) {
		id_partida = atoi(row[0]);
		sprintf(respuesta, "%s%d/", respuesta, id_partida);
		row = mysql_fetch_row(resultado);
		
		i++;
	}
		
	printf("%s\n", respuesta);
	// Si no hay filas en el resultado, devolver -1
	if (i == 0) {
		return -1;
	} else {
		return 1;
	}
}

int JugadoresEnEstadio(char stadio[20], MYSQL * conn, char respuesta[512]){
	
	int err;
	int id_jugador;
	char consulta[2048];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	
		
	printf("Dame el estadio\n");
	sprintf(consulta,"SELECT JUGADOR.ID FROM(JUGADOR, PARTIDA) WHERE PARTIDA.STADIO='%s';",stadio);
	err=mysql_query(conn, consulta);
	if (err != 0) {
		printf("Error en la consulta\n");
		mysql_errno(conn), mysql_error(conn);
		return -1;
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	// Recorrer todas las filas del resultado
	
	int i = 0;
	while (row!=NULL) {
		id_jugador = atoi(row[0]);
		sprintf(respuesta, "%s%d,", respuesta, id_jugador);
		row = mysql_fetch_row(resultado);
		
		i++;
	}
	// Si no hay filas en el resultado, devolver -1
	if (i == 0) {
		return -1;
	} else {
		return 1;
	}
}

int estadio(char stadio[20], MYSQL * conn){
	
	int err;
	int jugador_id;
	char consulta[2048];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	
	resultado=mysql_store_result(conn);
	err=mysql_query(conn, "SELECT JUGADOR.USERNAME, PARTIDA.STADIO FROM (JUGADOR, PARTIDA, PUNTUACIONES) WHERE JUGADOR.ID=PUNTUACIONES.JUGADOR_ID AND PUNTUACIONES.PARTIDA_ID=PARTIDA.ID AND PUNTUACIONES.GOLS >=2;");
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
}
