FROM openjdk:17 as builder

WORKDIR /app
COPY . /app

RUN microdnf install findutils

RUN ./gradlew clean build

FROM openjdk:17

WORKDIR /app

COPY --from=builder /app/build/libs/core.jar /app

EXPOSE 8000

CMD java -jar /app/core.jar
