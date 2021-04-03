package com.Eragoo.Lab4;

import lombok.NoArgsConstructor;

import java.io.Serializable;
import java.util.*;
import java.util.function.*;
import java.util.stream.Collectors;

import static java.util.stream.Collectors.toList;

@NoArgsConstructor
public class ProductStore implements Store<Weightable>, Serializable {
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

    @Override
    public Iterator<Weightable> iterator() {
        return storage.iterator();
    }

    @Override
    public void forEach(Consumer<? super Weightable> action) {
        storage.forEach(action);
    }

    @Override
    public Spliterator<Weightable> spliterator() {
        return storage.spliterator();
    }

    @Override
    public List<Weightable> getList() {
        return storage;
    }

    @Override
    public WoodStream<Weightable> map(Function<Weightable, Weightable> mapper) {
        storage = storage.stream().map(mapper).collect(toList());
        return this;
    }

    @Override
    public Collection<Waste> wasteThatMatches(Predicate<Weightable> wastePredicate) {
        List<Waste> wastes = storage.stream().filter(wastePredicate).map(weightable -> new Waste(weightable.getWeight())).collect(toList());
        storage = storage.stream().filter(wastePredicate.negate()).collect(toList());
        return wastes;
    }
}
