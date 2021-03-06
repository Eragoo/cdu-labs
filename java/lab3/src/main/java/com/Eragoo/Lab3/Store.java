package com.Eragoo.Lab3;

public interface Store<T> {
    boolean add(T element);
    int size();
}
