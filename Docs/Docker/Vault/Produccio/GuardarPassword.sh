#!/bin/bash
export VAULT_ADDR=https://127.0.0.1:8200
export VAULT_SKIP_VERIFY=true # Només si tens un certificat no vàlid
TOKEN=$(grep token init.json | cut -d":" -f2 | cut -d"\"" -f2)
UNSEAL_KEY=$(grep unseal_keys_b64 -a1 init.json | tail -n1 | cut -d "\"" -f2)

echo "Token: $TOKEN"

vault operator unseal $UNSEAL_KEY


vault login $TOKEN
vault secrets enable -path=secrets kv
vault kv put secrets/config/mssql password="Patata1234" username="SA"

vault kv get -field=password secrets/config/mssql
