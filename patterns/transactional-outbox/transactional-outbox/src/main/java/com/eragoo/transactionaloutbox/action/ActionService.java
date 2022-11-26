package com.eragoo.transactionaloutbox.action;

import com.eragoo.transactionaloutbox.outbox.OutboxService;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Set;
import java.util.stream.Collectors;

@Service
@AllArgsConstructor
public class ActionService {
    private final ActionRepository actionRepository;
    private final OutboxService outboxService;

    @Transactional
    public void create() {
        Action action = new Action();
        actionRepository.save(action);
        outboxService.save(action);
    }

    @Transactional(readOnly = true)
    public Set<ActionDto> getAll() {
        return actionRepository.findAll()
                .stream()
                .map(ActionDto::new)
                .collect(Collectors.toSet());
    }
}
