FROM node:19-alpine3.16 AS builder

WORKDIR /app
COPY package.json /app/package.json
RUN npm install --only=prod
COPY public/ /app/public
COPY src/ /app/src
COPY postcss.config.js /app/postcss.config.js
COPY tailwind.config.js /app/tailwind.config.js
COPY tsconfig.json /app/tsconfig.json

ARG NOTES_API_URL
ENV NOTES_API_URL=$NOTES_API_URL

RUN npm run build

FROM nginx:1.23.4-alpine
COPY --from=builder /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]




