package com.eragoo.transactionaloutbox.action;

import io.swagger.models.auth.In;
import jdk.jfr.Enabled;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.experimental.Accessors;

import javax.persistence.*;
import java.time.Instant;
import java.util.UUID;

@Entity
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class Action {
    private static final String GENERATOR = "action_generator";

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = GENERATOR)
    @SequenceGenerator(name = GENERATOR, sequenceName = "action_sequence")
    private Long id;

    private String randomStuff = UUID.randomUUID().toString();

    private Instant createdAt = Instant.now();
}
