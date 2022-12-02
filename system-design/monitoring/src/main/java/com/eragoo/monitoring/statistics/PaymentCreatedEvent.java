package com.eragoo.monitoring.statistics;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.math.BigDecimal;
import java.time.Instant;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
public class PaymentCreatedEvent {
    private Long id;
    private BigDecimal amount;
    private PaymentState state;
    private Instant createdAt = Instant.now();

    public boolean isSuccess() {
        return state == PaymentState.COMPLETE;
    }
}
