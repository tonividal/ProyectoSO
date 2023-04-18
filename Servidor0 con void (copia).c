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
	// Atenderemos solo 10 peticione
	
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
			p = strtok( NULL, "/");
			strcpy (username, p);
			
			
			int i;
			int sockets[100];
			pthread_t thread;
			i=0;
			/*if ((codigo !=0)&&(codigo!=6))
				
			{
				p = strtok (NULL, "/");
				
				strcpy(username, p);
				
				printf ("Codigo: %d, Nombre: %s\n", codigo, username);
			}*/
			if (codigo ==0) //petici?n de desconexi?n
			{
				
				terminar = 1;
				
			}
			else if (codigo == 6)
				
			{
				sprintf(respuesta, "%d", contador);
				
				printf("Respuesta: %s\n", respuesta);
				
				write(sock_conn, respuesta, strlen(respuesta));
			}
			
			else if(codigo == 1)
			{
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
					strcpy(respuesta1, "NO");
				}
				else
				{	
					strcpy(respuesta1, "SI");
					
				}
				
				
				write (sock_conn, respuesta1, strlen(respuesta1));
			}
			
			else if(codigo==3){//¿En qué partidas ha participado el "Playertwo"?
				printf("Codigo: %d, Username: %s\n", codigo, username);
				int resu = PartidasPlayerTwo(username, conn); //provar de borrar el bin
				sprintf(respuesta,"%d", resu);
				write(sock_conn, respuesta, strlen(respuesta));
			}
			
			else if (codigo ==4){ //¿Dime los jugadores que han jugado en un estadio?
				p = strtok (NULL, "/");
				strcpy(stadio, p);
				printf ("Codigo: %d, Estadio: %s\n", codigo, stadio);
				sprintf (respuesta,"%c", estadio(stadio, conn));
				write (sock_conn, respuesta, strlen(respuesta));
			}
			
			else if (codigo ==5){ //¿Dime qué jugadores han marcado dos o más goles y en qué estadio lo han hecho?
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
		serv_adr.sin_port = htons(9050);
		if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
			printf ("Error al bind");
		//La cola de peticiones pendientes no podr? ser superior a 4
		if (listen(sock_listen, 4) < 0)
			printf("Error en el Listen");
		
		int contador = 0;
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
int PartidasPlayerTwo(char username[20], MYSQL *connval, int* resultados, int max_resultados) {
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
	
	// Recorrer todas las filas del resultado
	int i = 0;
	while ((row = mysql_fetch_row(resultado)) && i < max_resultados) {
		int id_partida = atoi(row[0]);
		resultados[i] = id_partida;
		printf("%d\n", id_partida);
		i++;
	}
	// Si no hay filas en el resultado, devolver -1
	if (i == 0) {
		return -1;
	} else {
		return i;
	}
}


int JugadoresEnEstadio(char stadio[20], MYSQL * conn){
	
	int err;
	int id_jugador;
	char consulta[2048];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	
	printf("Dame el estadio\n");
	sprintf(consulta,"SELECT JUGADOR.ID FROM(JUGADOR, PARTIDA) WHERE PARTIDA.STADIO='%s';",stadio);
	err=mysql_query(conn, consulta);
	if(err!=0){
		printf("Error en la consulta\n");
		exit(1);}
	resultado=mysql_store_result(conn);
	
	
}

int estadio(char stadio[20], MYSQL * conn){
	
	int err;
	int jugador_id;
	char consulta[2048];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	
	err=mysql_query(conn, "SELECT JUGADOR.USERNAME, PARTIDA.STADIO FROM (JUGADOR, PARTIDA, PUNTUACIONES) WHERE JUGADOR.ID=PUNTUACIONES.JUGADOR_ID AND PUNTUACIONES.PARTIDA_ID=PARTIDA.ID AND PUNTUACIONES.GOLS >=2;");
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado=mysql_store_result(conn);
	
}

