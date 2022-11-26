package com.eragoo.transactionaloutbox.outbox;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

@Service
@AllArgsConstructor
public class OutboxService {
    private final OutboxRepository outboxRepository;
    private final ObjectMapper objectMapper;

    @Transactional(propagation = Propagation.MANDATORY)
    public <T> void save(T event) {
        try {
            String eventJson = objectMapper.writeValueAsString(event);
            outboxRepository.save(new Outbox(eventJson));
        } catch (JsonProcessingException e) {
            throw new RuntimeException(e);
        }
    }
}
