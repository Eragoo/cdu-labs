package com.Eragoo.lab5;

public interface Store<T> extends Iterable<T>, WoodStream<T> {
    boolean add(T element);
    int size();
}
