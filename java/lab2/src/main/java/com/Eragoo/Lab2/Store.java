package com.Eragoo.Lab2;

import lombok.NoArgsConstructor;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public interface Store<T> {
    boolean add(T element);
    int size();
}
