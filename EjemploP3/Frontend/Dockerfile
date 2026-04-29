# --- ETAPA 1: Construcción (Build) ---
FROM node:22-alpine AS build
WORKDIR /app

# Instalamos dependencias
COPY package*.json ./
RUN npm install

# Copiamos todo el código fuente y construimos
COPY . .
RUN npm run build

# --- ETAPA 2: Servidor Nginx (Producción) ---
FROM nginx:alpine

# Copiamos los archivos estáticos generados por Vite
COPY --from=build /app/dist /usr/share/nginx/html

# ¡MUY IMPORTANTE! Copiamos tu configuración personalizada de Nginx
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Exponemos el puerto 80 y arrancamos Nginx
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]