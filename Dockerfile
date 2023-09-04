FROM alpine:3.18.3 AS build

WORKDIR /src
COPY . .

CMD ["tail", "-f", "/dev/null"]