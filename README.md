"# TOProjectAPI" 
Para rodar o projeto, com visual studio, CTRL+f5 no projeto API  e depois executar o projeto de Teste Unidade

Para o Postman

Inserir Usuario e Login do usuário
-Para inserir usuario após rodar a api
http://localhost:36469/api/Usuarios/Inserir
post
Json Schema
  {
      "Nome": "b",
      "Email": "ronaldosoares.a@gmail.com",
			"Senha":"a",
			"Profiles_User":
			[{
				"Nivel":"dasdas "
			},
			 {
				"Nivel":"5345342523"
			},
			{
				"Nivel":"52442523532532534543"
			}]
}
para retornar o usuario criado
http://localhost:36469/api/Usuarios/Login
post
Json Schema{ "Email": "ronaldosoares.a@gmail.com", "Senha":"a" }
"# TOProjectAPI" 
OBS Gerais, criado token quando recupera o login, tempo de expiração 10 minutos, criado o swagger quando roda o projeto com os dois endpoints 
