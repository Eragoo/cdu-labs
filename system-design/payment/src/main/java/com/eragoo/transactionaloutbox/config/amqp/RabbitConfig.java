package com.eragoo.transactionaloutbox.config.amqp;

import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.core.*;
import org.springframework.amqp.rabbit.annotation.EnableRabbit;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
@EnableRabbit
@RequiredArgsConstructor
class RabbitConfig {

    static final String EVENT_TYPE_HEADER = "EVENT_TYPE";
    private static final String DEFAULT_EXCHANGE_NAME = "default";

    @Bean
    FanoutExchange defaultExchange() {
        return new FanoutExchange(DEFAULT_EXCHANGE_NAME);
    }

    @Bean
    DirectExchange directExchange() {
        return new DirectExchange("direct");
    }

    @Bean
    EventSender eventSender(
            RabbitTemplate rabbitTemplate,
            DirectExchange directExchange,
            ObjectMapper objectMapper
    ) {
        return new EventSender(rabbitTemplate, directExchange, objectMapper);
    }

    @Bean
    Queue queue(@Value("${spring.application.name}") String serviceName) {
        return new Queue(serviceName);
    }
}
