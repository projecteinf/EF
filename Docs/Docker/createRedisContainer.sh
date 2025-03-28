#!/bin/bash
sudo docker run -d --name redis-stack -p 6379:6379 -p 8001:8001 -v $(pwd)/redisdb/:/data redis/redis-stack:latest
