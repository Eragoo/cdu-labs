package com.eragoo.transactionaloutbox.config.amqp;

import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.AllArgsConstructor;
import lombok.SneakyThrows;
import lombok.extern.slf4j.Slf4j;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Message;
import org.springframework.amqp.core.MessageBuilder;
import org.springframework.amqp.rabbit.core.RabbitTemplate;

import static lombok.AccessLevel.PACKAGE;

@Slf4j
@AllArgsConstructor(access = PACKAGE)
public class EventSender {

    private final RabbitTemplate rabbitTemplate;
    private final DirectExchange directExchange;
    private final ObjectMapper objectMapper;
    public static String EVENT_TYPE = "DUMMY_EVENT";

    @SneakyThrows
    public <T> void send(T event) {
        final Message message = MessageBuilder.withBody(objectMapper.writeValueAsBytes(event))
                .setHeader(RabbitConfig.EVENT_TYPE_HEADER, EVENT_TYPE)
                .build();

        rabbitTemplate.send(directExchange.getName(), EVENT_TYPE, message);

        log.info("New event sent: {}, message: {}", event.toString(), new String(message.getBody()));
    }
}
