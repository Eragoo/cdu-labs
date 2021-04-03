package com.Eragoo.Lab4;

public interface Store<T> {
    boolean add(T element);
    int size();
}
