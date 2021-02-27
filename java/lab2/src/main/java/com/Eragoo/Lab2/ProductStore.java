package com.Eragoo.Lab2;

import lombok.NoArgsConstructor;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

@NoArgsConstructor
public class ProductStore implements Store<Weightable> {
    private List<Weightable> storage = new ArrayList<>();

    public ProductStore(Collection<Weightable> storage) {
        this.storage = new ArrayList<>(storage);
    }

    public boolean add(Weightable weightable) {
        return storage.add(weightable);
    }

    public int size() {
        return storage.size();
    }
}
