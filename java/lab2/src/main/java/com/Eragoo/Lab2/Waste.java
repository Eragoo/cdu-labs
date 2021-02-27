package com.Eragoo.Lab2;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@Getter
@AllArgsConstructor
@ToString
public class Waste implements Weightable {
    private final float weight;
}
