package com.eragoo.transactionaloutbox.payment;

import com.eragoo.transactionaloutbox.config.amqp.EventSender;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Set;
import java.util.stream.Collectors;

@Service
@AllArgsConstructor
public class PaymentService {
    private final PaymentRepository actionRepository;
    private final EventSender eventSender;

    @Transactional
    public void create() {
        Payment action = Payment.createDummy();
        actionRepository.save(action);
        eventSender.send(new PaymentDto(action));
    }

    @Transactional(readOnly = true)
    public Set<PaymentDto> getAll() {
        return actionRepository.findAll()
                .stream()
                .map(PaymentDto::new)
                .collect(Collectors.toSet());
    }
}
