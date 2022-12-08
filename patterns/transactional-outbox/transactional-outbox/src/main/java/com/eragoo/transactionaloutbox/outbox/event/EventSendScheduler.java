package com.eragoo.transactionaloutbox.outbox.event;

import com.eragoo.transactionaloutbox.config.amqp.EventSender;
import com.eragoo.transactionaloutbox.outbox.OutboxRepository;
import lombok.AllArgsConstructor;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

@Component
@AllArgsConstructor
public class EventSendScheduler {
    private final OutboxRepository outboxRepository;
    private final OutboxEventSendService outboxEventSendService;

    @Scheduled(cron = "*/5 * * * * ?")
    public void sendEvents() {
        outboxRepository.findAllIdByProcessedIsFalseOrderByCreatedAt()
                .forEach(outboxEventSendService::sendEvent);
    }
}
