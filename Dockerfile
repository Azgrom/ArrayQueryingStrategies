FROM alpine:3.18.3 AS build

ENV DOTNET_INSTALL_DIR /src

RUN apk update
RUN apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib wget libgdiplus

WORKDIR /src
COPY ./dotnet-install.sh .

RUN chmod +x ./dotnet-install.sh
RUN ./dotnet-install.sh -c 3.1
RUN ./dotnet-install.sh -c 5.0
RUN ./dotnet-install.sh -c 6.0
RUN ./dotnet-install.sh -c 7.0
RUN ./dotnet-install.sh -c 8.0

COPY . .

CMD ["./dotnet", "run", "-c", "Release", "--framework", "net7.0"]
