package com.Eragoo.Lab1;

import lombok.NoArgsConstructor;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

@NoArgsConstructor
public class ProductStore {
    private List<Timber> storage = new ArrayList<>();

    public ProductStore(Collection<Timber> storage) {
        this.storage = new ArrayList<>(storage);
    }

    public boolean add(Timber timber) {
        return storage.add(timber);
    }

    public int size() {
        return storage.size();
    }
}
