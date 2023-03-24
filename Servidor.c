#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
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
	serv_adr.sin_port = htons(9040);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	int i;
	// Atenderemos solo 10 peticione
	for(i=0;i<10;i++){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexi?n\n");
		//sock_conn es el socket que usaremos para este cliente
		
		// Ahora recibimos su peticion
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibida una petición\n");
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
	}

		//Escribimos la peticion en la consola
		
		printf("La peticion es: %s\n",peticion);
		char *p = strtok(peticion, "/");
		int codigo =  atoi (p);
		p = strtok( NULL, "/");
		char username[20];
		char password[20], stadio[20];
		strcpy (username, p);
		printf ("Codigo: %d, username: %s\n", codigo, username);
		
		if (codigo ==1) { //El usuario pide loguearse.
			p = strtok (NULL, "/");
			strcpy(password, p);
			printf ("Codigo: %d, Username: %s\n", codigo, username, password);
			MYSQL *conn;
			int err;
			char consulta[100];
			MYSQL_RES *resultado;
			MYSQL_ROW row;

			//Creamos una conexion al servidor MYSQL 
			conn = mysql_init(NULL);
			if (conn==NULL) {
				printf ("Error al crear la conexión: %u %s\n", 
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
			}
			
		}
			
		else if (codigo ==2){ //¿En qué partidas ha participado el "Playertwo"?
			printf("Codigo: %d, Username: %s\n", codigo, username);
			sprintf(respuesta,"%d", PartidasPlayerTwo(username));
			write(sock_conn, respuesta, strlen(respuesta));
		}
		
		else if (codigo ==3){ //¿Dime los jugadores que han jugado en un estadio?
			p = strtok (NULL, "/");
			strcpy(stadio, p);
			printf ("Codigo: %d, Estadio: %s\n", codigo, stadio);
			sprintf (respuesta,"%c", Estadio(stadio));
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		else if (codigo ==4){ //¿Dime qué jugadores han marcado dos o más goles y en qué estadio lo han hecho?
			sprintf (respuesta,"%c","%c%", Estadio(stadio));
			write (sock_conn, respuesta, strlen(respuesta));
			
			
		}
}

int PartidasPlayerTwo(char username[20]){
	MYSQL *conn;
	int err;
	int partida_id;
	char jugador[20],consulta[150];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	conn=mysql_init(NULL);
	if(conn==NULL){
		printf("Error al crear la conexión\n");
		exit(1);}
	conn=mysql_real_connect(conn,"localhost","root","mysql","game",0,NULL,0);
	if(conn==NULL){
		printf("Error al conectar\n");
		exit(1);}
	printf("Dame el jugador\n");
	scanf("%s",jugador);
	sprintf(consulta,"SELECT PARTIDA.ID FROM(JUGADOR, PARTIDA, PUNTUACIONES) WHERE JUGADOR.ID='%d' AND JUGADOR.ID=PUNTUACIONES.JUGADOR_ID AND PARTIDA.ID=PUNTUACIONES.PARTIDA_ID",jugador);
	err=mysql_query(conn, consulta);
	if(err!=0){
		printf("Error en la consulta\n");
		exit(1);}
	resultado=mysql_store_result(conn);
	
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	exit(0);
	
}

int Estadio(char stadio[20]){
	MYSQL *conn;
	int err;
	int id_jugador;
	char consulta[150];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	conn=mysql_init(NULL);
	if(conn==NULL){
		printf("Error al crear la conexión\n");
		exit(1);}
	conn=mysql_real_connect(conn,"localhost","root","mysql","game",0,NULL,0);
	if(conn==NULL){
		printf("Error al conectar\n");
		exit(1);}
	printf("Dame el estadio\n");
	scanf("%s",stadio);
	sprintf(consulta,"SELECT JUGADOR.ID FROM(JUGADOR, PARTIDA) WHERE PARTIDA.STADIO='%s'",stadio);
	err=mysql_query(conn, consulta);
	if(err!=0){
		printf("Error en la consulta\n");
		exit(1);}
	resultado=mysql_store_result(conn);
	
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	exit(0);
	
}

int estadio(char stadio[20]){
	MYSQL *conn;
	int err;
	int jugador_id;
	char consulta[150];
	MYSQL_RES*resultado;
	MYSQL_ROW row;
	conn=mysql_init(NULL);
	if(conn==NULL){
		printf("Error al crear la conexión\n");
		exit(1);}
	conn=mysql_real_connect(conn,"localhost","root","mysql","game",0,NULL,0);
	if(conn==NULL){
		printf("Error al conectar\n");
		exit(1);}
	
	err=mysql_query(conn, "SELECT JUGADOR.USERNAME, PARTIDA.STADIO FROM (JUGADOR, PARTIDA, PUNTUACIONES) WHERE JUGADOR.ID=PUNTUACIONES.JUGADOR_ID AND PUNTUACIONES.PARTIDA_ID=PARTIDA.ID AND PUNTUACIONES.GOLS >=2");
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado=mysql_store_result(conn);
	
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	exit(0);
	
}
