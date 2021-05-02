package com.Eragoo.Lab4;

import java.util.Collection;
import java.util.List;
import java.util.function.BiFunction;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Stream;

public interface WoodStream<T> {
    List<T> getList();
    WoodStream<T> map(Function<T, T> map);
    Collection<Waste> wasteThatMatches(Predicate<T> wastePredicate);
}
