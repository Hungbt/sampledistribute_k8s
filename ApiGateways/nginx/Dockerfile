FROM nginx:1.23.1-alpine
RUN rm /etc/nginx/conf.d/default.conf
COPY /ApiGateways/nginx/default.conf /etc/nginx/conf.d/default.conf
VOLUME /etc/nginx