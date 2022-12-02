package com.eragoo.transactionaloutbox.payment;

import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Set;

@RestController
@RequestMapping("/payments")
@Slf4j
@RequiredArgsConstructor
public class PaymentResource {
    public final PaymentService paymetService;

    @PostMapping
    public void addDummyPayment() {
        paymetService.create();
    }

    @GetMapping
    public Set<PaymentDto> getAll() {
        return paymetService.getAll();
    }
}
