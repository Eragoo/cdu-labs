package com.eragoo.monitoring.config.amqp;

import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.core.*;
import org.springframework.amqp.rabbit.annotation.EnableRabbit;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.autoconfigure.condition.ConditionalOnBean;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.List;

@Configuration
@EnableRabbit
@RequiredArgsConstructor
class RabbitConfig {

    static final String EVENT_TYPE_HEADER = "EVENT_TYPE";
    private static final String DEFAULT_EXCHANGE_NAME = "default";

    //todo use that exchange
    @Bean
    FanoutExchange defaultExchange() {
        return new FanoutExchange(DEFAULT_EXCHANGE_NAME);
    }

    @Bean
    DirectExchange directExchange() {
        return new DirectExchange("direct");
    }

    @Bean
    Queue queue(@Value("${spring.application.name}") String serviceName) {
        return new Queue(serviceName);
    }

    @Bean
    Declarables bindings(Queue queue, FanoutExchange defaultExchange, DirectExchange directExchange) {
        return new Declarables(
                queue,
                defaultExchange,
                directExchange,
                BindingBuilder.bind(queue).to(defaultExchange),
                BindingBuilder.bind(queue).to(directExchange).with("PAYMENT_CREATED_EVENT")
        );
    }

    @Bean
    @ConditionalOnBean(Queue.class)
    EventReceiver eventReceiver(ApplicationEventPublisher eventPublisher, ObjectMapper objectMapper) {
        return new EventReceiver(eventPublisher, objectMapper);
    }
}
