package com.Eragoo.Lab4;

import java.util.Collection;

public interface Store<T> extends Iterable<T>, WoodStream<T> {
    boolean add(T element);
    int size();
}
