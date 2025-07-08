# 🛒 PedidoExpress

Sistema de pedidos assíncrono utilizando .NET 8 com RabbitMQ, arquitetura orientada a mensagens e Docker.

## 📦 Visão Geral

O **PedidoExpress** é uma aplicação composta por três projetos:

- `Pedido.API`: API REST para recebimento de pedidos.
- `Pedido.Worker`: Worker service que consome mensagens da fila e processa os pedidos.
- `RabbitMQ`: Broker de mensagens para comunicação assíncrona entre os serviços.

Este projeto simula um cenário de microsserviços desacoplados, ideal para aplicações escaláveis e resilientes.

---

## 🚀 Tecnologias Utilizadas

- ✅ ASP.NET Core 8
- ✅ RabbitMQ
- ✅ Docker & Docker Compose
- ✅ Swagger (OpenAPI 3.0)
- ✅ MediatR (opcional)
- ✅ Comunicação assíncrona via filas
- ✅ Arquitetura limpa e organizada (Domain, Application, Infra, Worker)

---

## 🔁 Fluxo da Aplicação

1. Um cliente envia um **pedido** via API HTTP POST.
2. A API publica o pedido na fila `pedido-express` no RabbitMQ.
3. O Worker consome a mensagem da fila e realiza o processamento (pode ser persistência, notificação etc).

---

## 📂 Estrutura de Pastas

```bash
src/
│
├── Pedido.API/           # API REST com endpoint POST /api/pedidos
│   ├── Controllers/
│   ├── Messaging/        # Interfaces e implementação de IMessageBus
│   ├── Models/           # PedidoModel com cliente, produto, quantidade
│   └── Program.cs
│
├── Pedido.Worker/        # Worker que consome mensagens do RabbitMQ
│   └── Program.cs
│
└── Pedido.API.Tests/     # Projeto de testes automatizados (em construção)
```

---

## 📬 Exemplo de Requisição

### Endpoint
```
POST /api/pedidos
```

### JSON de Exemplo

```json
{
  "cliente": "João Silva",
  "produto": "Notebook",
  "quantidade": 2
}
```

---

## 🐳 Docker

O projeto está preparado para rodar 100% via Docker com apenas um comando!

### Pré-requisitos

- Docker instalado
- Docker Compose

### Subindo o ambiente

```bash
docker-compose up --build
```

- Acesse a API: [http://localhost:5000/swagger](http://localhost:5000/swagger)
- RabbitMQ Management UI: [http://localhost:15672](http://localhost:15672)  
  (usuário: `guest`, senha: `guest`)

---

## 📸 Prints

### Swagger
![Swagger](./imgs/swagger.png)

### Estrutura do Projeto
![Estrutura](./imgs/estrutura.png)

### Docker Compose
![Docker](./imgs/docker.png)

---

## 🧪 Testes

Projeto `Pedido.API.Tests` está sendo preparado para incluir testes de integração e testes unitários com xUnit.

---

## ✍️ Autor

Desenvolvido por [Renan Muniz](https://github.com/RenanMunizDev) 💻  
Se curtiu esse projeto, deixe uma ⭐ no repositório e me segue no GitHub!

---

## 📌 TODO

- [x] API com endpoint de pedidos
- [x] Integração com RabbitMQ
- [x] Worker para processamento de pedidos
- [x] Swagger para documentação
- [x] Docker e Docker Compose
- [x] Testes automatizados com xUnit
- [x] Deploy CI/CD com GitHub Actions

---

## 📄 Licença

Este projeto está sob a licença MIT. Sinta-se livre para usar e contribuir.