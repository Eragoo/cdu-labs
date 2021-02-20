package com.Eragoo.Lab1;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

import java.util.Objects;

@Getter
@ToString
@AllArgsConstructor
public class Wood {
    private final long id;
    private final String name;
    private final float density;

    public Wood(Wood wood) {
        this.id = wood.getId();
        this.density = wood.getDensity();
        this.name = wood.getName();
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Wood wood = (Wood) o;
        return id == wood.id && Float.compare(wood.density, density) == 0 && name.equals(wood.name);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, name, density);
    }
}
