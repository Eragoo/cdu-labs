package com.Eragoo.lab5;

import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;

import java.io.Serializable;
import java.util.*;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Collectors;
import java.util.stream.Stream;

@AllArgsConstructor
@NoArgsConstructor
public class WoodDirectory implements Store<Wood>, Serializable {
    private TreeMap<Long, Wood> storage = new TreeMap<>();

    public WoodDirectory(Collection<Wood> woods) {
        this.storage = collectToTreeMap(woods.stream());
    }

    public Wood get(long id) {
        return storage.get(id);
    }

    public boolean add(Wood wood) {
        if (storage.containsKey(wood.getId())) {
            return false;
        }
        storage.put(wood.getId(), wood);
        return true;
    }

    @Override
    public int size() {
        return storage.size();
    }

    @Override
    public String toString() {
        return "WoodDirectory{" +
                "storage=" + storage +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        WoodDirectory that = (WoodDirectory) o;
        return storage.equals(that.storage);
    }

    @Override
    public int hashCode() {
        return Objects.hash(storage);
    }

    @Override
    public Iterator<Wood> iterator() {
        return storage.values().iterator();
    }

    @Override
    public void forEach(Consumer<? super Wood> action) {
        storage.values().forEach(action);
        storage = collectToTreeMap(storage.values().stream());
    }

    @Override
    public Spliterator<Wood> spliterator() {
        return storage.values().spliterator();
    }

    @Override
    public List<Wood> getList() {
        return new ArrayList<>(storage.values());
    }

    @Override
    public WoodStream<Wood> map(Function<Wood, Wood> map) {
       storage = collectToTreeMap(storage.values().stream().map(map));
       return this;
    }

    @Override
    public Collection<Waste> wasteThatMatches(Predicate<Wood> wastePredicate) {
        List<Waste> wastes = storage.values().stream()
                .filter(wastePredicate)
                .map(wood -> new Waste(1))
                .collect(Collectors.toList());

        storage = collectToTreeMap(storage.values().stream().filter(wastePredicate.negate()));
        return wastes;
    }

    @Override
    public WoodStream<Wood> remove(Predicate<Wood> predicate) {
        Predicate<Wood> negate = predicate.negate();
        storage = collectToTreeMap(storage.values().stream().filter(negate));
        return this;
    }

    @Override
    public void doOnlyFor(Predicate<Wood> predicate, Consumer<Wood> action) {
        List<Wood> processed = new ArrayList<>();
        for (Wood value : storage.values()) {
            if (predicate.test(value)) {
                action.accept(value);
            }
            processed.add(value);
        }

        storage = collectToTreeMap(processed.stream());
    }

    private TreeMap<Long, Wood> collectToTreeMap(Stream<Wood> stream) {
        return stream.collect(Collectors.toMap(
                    Wood::getId,
                    Wood::new,
                    (w1, w2)-> {throw new IllegalStateException("Duplicate key");},
                    TreeMap::new
                ));
    }
}
