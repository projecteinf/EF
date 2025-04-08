#!/bin/bash
# Instal·lació client vault
dpkg --get-selections | grep vault > /dev/null
if [[ $? -ne 0 ]]
    then 
        curl -fsSL https://apt.releases.hashicorp.com/gpg | sudo gpg --dearmor -o /usr/share/keyrings/hashicorp-archive-keyring.gpg
        echo "deb [signed-by=/usr/share/keyrings/hashicorp-archive-keyring.gpg] https://apt.releases.hashicorp.com $(lsb_release -cs) main" | sudo tee /etc/apt/sources.list.d/hashicorp.list
        sudo apt update && sudo apt install vault
fi


# Generar claus
openssl genpkey -algorithm RSA -out ./certs/vault.key
openssl req -new -key ./certs/vault.key -out ./certs/vault.csr
openssl x509 -req -in ./certs/vault.csr -signkey ./certs/vault.key -out ./certs/vault.crt -extensions v3_req -extfile ./config/openssl.cnf
chmod 644 ./certs/vault.key
sudo cp ./certs/vault.crt /etc/ssl/certs/   # Per tal que la màquina client reconeixi el certificat

docker volume inspect vault-data
sudo chown -R 100 /var/lib/docker/volumes/vault-data/_data
