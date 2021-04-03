package com.Eragoo.Lab4;

import lombok.Getter;
import lombok.ToString;

import java.io.Serializable;
import java.util.Objects;

import static org.apache.commons.lang3.StringUtils.isBlank;

@Getter
@ToString
public class Wood implements Serializable {
    private final long id;
    private final String name;
    private final float density;

    /**
     *
     * @param wood must be not null
     */
    public Wood(Wood wood) {
        if(wood == null) {
            throw new IllegalArgumentException("Wood must be not null");
        }
        this.id = wood.getId();
        this.density = wood.getDensity();
        this.name = wood.getName();
    }

    public Wood(long id, String name, float density) {
        if(id <= 0  || isBlank(name) || density <= 0) {
            throw new IllegalArgumentException();
        }
        this.id = id;
        this.name = name;
        this.density = density;
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
