#!/bin/bash

# sudo chown -R 100 /var/lib/docker/volumes/vault-data/_data

mkdir -p ./vault-data

sudo chown -R 100 ./vault-data

docker-compose up -d # -d per tal que s'executi en background

echo "==> Esperant que Vault estigui llest..."

until curl -sk https://127.0.0.1:8200/v1/sys/health > /dev/null 2>&1; do
    echo "   -> Vault encara no està llest. Esperant..."
    sleep 2
done

echo "==> Exportant variables VAULT..."
export VAULT_ADDR=https://127.0.0.1:8200
export VAULT_SKIP_VERIFY=true

echo "==> Inicialitzant Vault..."
vault operator init -key-shares=1 -key-threshold=1 -format=json > init.json

if [ $? -ne 0 ]; then
    echo "⚠️  Error en la inicialització de Vault."
    exit 1
fi


UNSEAL_KEY=$(jq -r '.unseal_keys_b64[0]' init.json)

echo "==> Fent unseal amb la clau: $UNSEAL_KEY"
vault operator unseal "$UNSEAL_KEY"

echo "✅ Vault inicialitzat i dessegellat!"
