package com.eragoo.transactionaloutbox.payment;

import lombok.Getter;

import java.math.BigDecimal;
import java.util.Objects;

@Getter
public class PaymentDto {
    private final Long id;
    private final BigDecimal amount;
    private final PaymentState state;

    public PaymentDto(Payment payment) {
        this.id = payment.getId();
        this.amount = payment.getAmount();
        this.state = payment.getState();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        PaymentDto actionDto = (PaymentDto) o;

        return Objects.equals(id, actionDto.id);
    }

    @Override
    public int hashCode() {
        return id != null ? id.hashCode() : 0;
    }
}
