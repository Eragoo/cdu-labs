package com.eragoo.transactionaloutbox.action;

import lombok.Getter;

import java.time.Instant;
import java.util.Objects;

@Getter
public class ActionDto {
    private final Long id;
    private final String randomStuff;
    private final Instant createdAt;

    public ActionDto(Action action) {
        this.id = action.getId();
        this.randomStuff = action.getRandomStuff();
        this.createdAt = action.getCreatedAt();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        ActionDto actionDto = (ActionDto) o;

        return Objects.equals(id, actionDto.id);
    }

    @Override
    public int hashCode() {
        return id != null ? id.hashCode() : 0;
    }
}
