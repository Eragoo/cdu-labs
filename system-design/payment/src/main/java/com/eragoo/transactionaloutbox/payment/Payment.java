package com.eragoo.transactionaloutbox.payment;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.math.BigDecimal;
import java.time.Instant;
import java.util.UUID;
import java.util.concurrent.ThreadLocalRandom;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class Payment {
    private static final String GENERATOR = "payment_generator";

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = GENERATOR)
    @SequenceGenerator(name = GENERATOR, sequenceName = "payment_sequence")
    private Long id;

    private BigDecimal amount;

    private PaymentState state;

    public static Payment createDummy() {
        Payment payment = new Payment();
        payment.amount = ThreadLocalRandom.current().nextDouble() < 0.5 ? BigDecimal.ONE : BigDecimal.TEN;
        payment.state = ThreadLocalRandom.current().nextDouble() < 0.5 ? PaymentState.COMPLETE : PaymentState.FAILED;
        return payment;
    }
}
