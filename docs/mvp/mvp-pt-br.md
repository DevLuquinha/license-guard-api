# MVP de LicenseGuard API

Autor: Lucas Emmanuel Rodrigues Firmino de Paula
Data: 19/01/2026 <br>
Resumo: Documento descrevendo o escopo mínimo viável (MVP) para a API de licenciamento LicenseGuard.

## Checklist do MVP

[ ] O que é uma licença no LicenseGuard? <br>
[ ] O que não entra no MVP? <br>
[ ] Casos de uso essenciais <br>
[ ] Regras de negócios mínimas

## O que é uma licença no LicenseGuard?
Uma licença no LicenseGuard é uma autorização técnica que permite que um software cliente seja executado sob determinadas condições.

No MVP, uma licença:
- possui uma license key única
- pode estar ativa, expirada ou revogada
- pode ter uma data de expiração
- pode ser associada a um ou mais dispositivos
- é validada exclusivamente pelo backend LicenseGuard API
- Um dispositivo é representado por um identificador fornecido pelo software cliente.
- Uma license key identifica uma única licença.

### "A licença não representa pagamento, plano comercial ou usuário final."

## O que não entra no MVP?
No MVP, não fazem parte do escopo:
- Sistemas de pagamento
- Assinaturas ou planos
- Renovação automática
- Trial controlado por tempo de uso
- Multi-tenant (empresas / organizações)
- Webhooks
- Dashboard administrativo
- Controle avançado de permissões
- Limitação por usuário humano
- Fingerprint avançado de hardware

- Rate limiting sofisticado

### "O objetivo do MVP é validar o núcleo do sistema de licenciamento, não um produto SaaS completo."

---
## Casos de uso essenciais
## 1. Criar uma licença
- Gera uma license key segura
- Define status inicial
- Pode definir data de expiração

## 2. Validar uma licença
Recebe:
- license key
- identificador do dispositivo

Retorna:
- válida ou inválida
- motivo da invalidação (expirada, revogada, dispositivo não autorizado)

## 3. Associar dispositivo à licença
- Opcionalmente limitado a N dispositivos
- Primeiro uso pode registrar o dispositivo

## 4. Revogar uma licença
- Licença revogada não pode mais ser validada
- A revogação é permanente

## 5. Consultar informações básicas da licença
- Status
- Expiração
- Quantidade de dispositivos associados

## Regras de negócio mínimas (Domain Rules)
- Uma license key deve ser única e imprevisível.
- Uma licença revogada nunca volta a ser válida.
- Uma licença expirada não pode ser validada.
- Um dispositivo não autorizado invalida a validação.
- Uma licença pode ter zero ou mais dispositivos associados.
- A validação da licença não depende de estado do cliente.
- Toda decisão de validade deve ser determinística.