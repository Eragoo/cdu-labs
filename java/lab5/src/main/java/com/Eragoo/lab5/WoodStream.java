package com.Eragoo.lab5;

import java.util.Collection;
import java.util.List;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;

public interface WoodStream<T> {
    List<T> getList();
    WoodStream<T> map(Function<T, T> map);
    Collection<Waste> wasteThatMatches(Predicate<T> wastePredicate);
    WoodStream<T> remove(Predicate<T> predicate);
    void doOnlyFor(Predicate<T> predicate, Consumer<T> action);
}
