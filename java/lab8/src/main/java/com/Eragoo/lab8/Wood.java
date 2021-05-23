package com.Eragoo.lab8;

import java.util.Random;

public class Wood {
    private long id;
    private String name;
    private String description;

    public Wood(String name, String description) {
        this.id = new Random().nextInt();
        this.name = name;
        this.description = description;
    }

    public long getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
