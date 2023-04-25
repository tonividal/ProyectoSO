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
int port=9070;

//Estructura de datos para almacenar 50 conectados
typedef struct{
	char nombre[20];
	int socket;
	
}Conectado;

typedef struct{
	Conectado conectados[50];
	int num;
}ListaConectados;

ListaConectados milista;
char conectados[50];

void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	char respuesta1[512];
	int ret;
	int sock_listen;
	struct sockaddr_in serv_adr;
	
	int i;
	int terminar=0;
	char username[20];
	char password[20], stadio[20];
	// Atenderemos solo 10 peticiones
	
	
	//Creamos conexion sql (ya está dentro del while pero lo volvemos a hacer para la lista de conectados)
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
		
	
	
		while(!terminar){
			
			
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
			/*if ((codigo !=0)&&(codigo!=6))
				
			{
				p = strtok (NULL, "/");
				
				strcpy(username, p);
				
				printf ("Codigo: %d, Nombre: %s\n", codigo, username);
			}*/
			if (codigo ==0) //petici?n de desconexi?n
			{
				int res = EliminarConectado(username, &milista);
				if (res==-1)
					printf("Error al eliminar usuario\n");
				else
					printf("Usuario eliminado correctamente\n");
				
				terminar = 1;
				
			}
			else if (codigo == 6)
				
			{
				char ListaConectados[200];
				DameConectados(&milista, ListaConectados);
				write (sock_conn, ListaConectados, strlen(ListaConectados));
			}
			
			else if(codigo == 1)
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
					printf ("Error al inicializar la conexión: %u %s\n", 
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
					strcpy(respuesta1, "NO");
				}
				else
				{	
					strcpy(respuesta1, "SI");
					
					//Añadimos al usuario a la Lista de Conectados
					int res = AnadirConectado(username, socket, &milista);
					if (res==-1)
						printf("La lista está llena\n");
					else
						printf("Añadido correctamente\n");
					
					int socket= DameSocket(&milista, username);
					if (socket!=-1)
						printf("'%s' -> %d\n", username, socket);
					else
						printf("Ese usuario no existe\n");
					
					char ListaConectados[200];
					DameConectados(&milista, ListaConectados);
					printf("Resultado:'%s'\n", ListaConectados);
					
				}
				
				
				write (sock_conn, respuesta1, strlen(respuesta1));
			}
			
			else if(codigo==3){//Â¿En quÃ© partidas ha participado el "Playertwo"?
				p = strtok( NULL, "/");
				strcpy (username, p);
				printf("Codigo: %d, Username: %s\n", codigo, username);
				int resu = PartidasPlayerTwo(username, conn, respuesta); //provar de borrar el bin
				if (resu==-1)
					strcpy(respuesta, "No hay resultados");
				//sprintf(respuesta,"%d", resu);
				write(sock_conn, respuesta, strlen(respuesta));
				strcpy(respuesta, "");
			}
			
			else if (codigo ==4){ //Â¿Dime los jugadores que han jugado en un estadio?
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
			
			else if (codigo ==5){ //Â¿Dime quÃ© jugadores han marcado dos o mÃ¡s goles y en quÃ© estadio lo han hecho?
				sprintf (respuesta,"%c","%c%", JugadoresEnEstadio(stadio, conn));
				write (sock_conn, respuesta, strlen(respuesta));
			}
			
			if ((codigo == 3)||(codigo == 4)||(codigo == 5)||(codigo == 6))
				
			{
				
				pthread_mutex_lock( &mutex ); //que no interrumpa
				contador =  contador + 1;
				pthread_mutex_unlock( &mutex ); //ya puede interrumpir
				
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
	int encontrado = 0;
	while (encontrado == 0 && lista->num != i){
		if(strcmp(lista->conectados[i].nombre,nombre) == 0)
			encontrado = 1;
		else
			i++;
	}
	if (encontrado == 0)
		return -1;
	else
		return lista->conectados[i].socket;
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
			pthread_mutex_lock(&mutex);
			lista->conectados[i].socket = lista->conectados[i+1].socket;
			strcpy(lista->conectados[i].nombre,lista->conectados[i+1].nombre);
			lista->num = lista->num -1;
			pthread_mutex_unlock(&mutex);
		}
		return 0;
		
	}
}
void DameConectados(ListaConectados *milista, char resultado[200])
{
	sprintf(resultado,"%d/",milista->num);
	int i;
	for(i = 0; i < milista->num; i++){
		sprintf(resultado,"%s%s/",resultado,milista->conectados[i].nombre);
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
		int sockets[100];
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
		
		//sock_conn es el socket que usaremos para este cliente
		
		
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
		sprintf(respuesta, "%s%d,", respuesta, id_partida);
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

