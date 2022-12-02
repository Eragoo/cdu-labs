package com.eragoo.monitoring.config.amqp;

import com.eragoo.monitoring.statistics.PaymentCreatedEvent;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.AllArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.amqp.core.Message;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.messaging.handler.annotation.Header;

import java.io.IOException;

import static lombok.AccessLevel.PACKAGE;

@Slf4j
@AllArgsConstructor(access = PACKAGE)
public class EventReceiver {
    private final ApplicationEventPublisher applicationEventPublisher;
    private final ObjectMapper objectMapper;

    @RabbitListener(queues = "#{queue.name}", concurrency = "1-2")
    void onEventReceived(Message message, @Header(RabbitConfig.EVENT_TYPE_HEADER) String typeOfEvent) {
        try {
            final Object event = objectMapper.readValue(message.getBody(), PaymentCreatedEvent.class);
            log.info("New event received: {}, message: {}", event.toString(), new String(message.getBody()));
            applicationEventPublisher.publishEvent(event);
        } catch (IOException e) {
            log.error(e.getMessage(), e);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
