package com.eragoo.transactionaloutbox.outbox.event;

import com.eragoo.transactionaloutbox.config.amqp.EventSender;
import com.eragoo.transactionaloutbox.outbox.OutboxRepository;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@AllArgsConstructor
public class OutboxEventSendService {
    private final OutboxRepository outboxRepository;
    private final EventSender eventSender;

    @Transactional
    public void sendEvent(Long outboxId) {
        if (outboxId == null) return;
        outboxRepository.findById(outboxId)
                .ifPresent(outbox -> {
                    eventSender.send(outbox.getEvent());
                    outbox.setProcessed(true);
                });
    }
}
