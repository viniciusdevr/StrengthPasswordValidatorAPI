# StrengthPasswordValidatorAPI

API simples em ASP.NET Core (.NET 9) que valida a força de uma senha aplicando um conjunto de regras.

## Como rodar

```bash
dotnet run
```

A aplicação sobe (perfis definidos em `Properties/launchSettings.json`) em:
- `http://localhost:5182`
- `https://localhost:7161`

Em ambiente de Development, o schema OpenAPI fica disponível em `/openapi/v1.json`.

## Design

### Strategy

A interface `IPasswordRuleStrategy` define um único método:

```csharp
PasswordNotification Validate(string password);
```

Cada regra de senha é implementada como uma classe separada que segue esse contrato:

- `MinimumLengthStrategy` — mínimo de 8 caracteres
- `RequiredNumberStrategy` — pelo menos um dígito
- `RequiredUpperCaseStrategy` — pelo menos uma letra maiúscula
- `RequiredLowerCaseStrategy` — pelo menos uma letra minúscula
- `RequiredSpecialCharacterStrategy` — pelo menos um caractere especial
- `NoRepeatedCharacterStrategy` — sem caracteres repetidos em sequência

Isso permite adicionar, remover ou alterar uma regra sem tocar nas outras.

### Notification

Em vez de lançar uma exceção a cada regra que falha, cada strategy devolve um `PasswordNotification` (`IsValid` + `Message`). O `ValidatePasswordService` roda a senha por todas as strategies e acumula, numa lista, apenas as notifications inválidas — assim é possível reportar **todos** os problemas da senha de uma vez, e não só o primeiro que falhar.

## Fluxo da requisição

1. Cliente faz `POST /api/Password/validate` com a senha em JSON.
2. `PasswordController` faz o bind do corpo para `Password` (propriedade `GivenPassword`).
3. O controller chama `IValidatePasswordService.Validate(password.GivenPassword)`.
4. `ValidatePasswordService` roda a senha por todas as `IPasswordRuleStrategy` e acumula as notifications inválidas.
5. O controller responde de acordo com o resultado.

## Endpoint

```
POST https://localhost:7161/api/Password/validate
Content-Type: application/json
```

Body:
```json
{
  "givenPassword": "Teste@123"
}
```

Respostas:
- `200 OK` — a senha atende todas as regras.
- `400 Bad Request` — array com as notifications das regras que falharam, por exemplo:
  ```json
  [
    { "isValid": false, "message": "Password must be at least 8 characters long." }
  ]
  ```
- `500 Internal Server Error` — senha nula/vazia ou erro inesperado.

Exemplo com `curl`:

```bash
curl -k -X POST https://localhost:7161/api/Password/validate \
  -H "Content-Type: application/json" \
  -d "{\"givenPassword\": \"Teste@123\"}"
```
