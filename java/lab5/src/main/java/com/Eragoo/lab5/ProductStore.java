package com.Eragoo.lab5;

import lombok.NoArgsConstructor;

import java.io.Serializable;
import java.util.*;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;
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

    @Override
    public WoodStream<Weightable> remove(Predicate<Weightable> predicate) {
        Predicate<Weightable> negate = predicate.negate();
        storage = storage.stream()
                .filter(negate)
                .collect(Collectors.toList());

        return this;
    }

    @Override
    public void doOnlyFor(Predicate<Weightable> predicate, Consumer<Weightable> action) {
        List<Weightable> result = new ArrayList<>();
        for (Weightable weightable : storage) {
            if (predicate.test(weightable)) {
                action.accept(weightable);
            }
            result.add(weightable);
        }

        storage = result;
    }
}
