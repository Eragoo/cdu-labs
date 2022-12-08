package com.eragoo.transactionaloutbox.config;

import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import javax.annotation.PostConstruct;

@Service
@AllArgsConstructor
public class DebeziumConfig {
    private final RestTemplate restTemplate;

//https://fullstackdeveloper.guru/2022/05/05/how-to-implement-change-data-capture-cdc-using-debezium/
    @PostConstruct
    public void sendConfigurationRequest() {
        String body = "{" +
            "name: \"inventory-connector\"," +
            "config: {"+
            "connector.class: \"io.debezium.connector.postgresql.PostgresConnector\"," +
            "tasks.max:\"1\","+
            "database.hostname:\"db-core\","+
            "database.port:\"5432\","+
            "database.user:\"core_dbu\","+
            "database.password:\"pass\","+
            "database.server.id:\"184054\","+
            "database.server.name:\"dbserver1\","+
            "database.include.list:\"outbox\","+
            "database.history.kafka.bootstrap.servers:\"kafka:9092\","+
            "database.history.kafka.topic:\"schema-changes.outbox\""+
            "}";

        restTemplate.postForObject("http://localhost:8083/connectors", body, String.class);
    }
}
