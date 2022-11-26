package com.eragoo.transactionaloutbox.outbox;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import org.hibernate.annotations.Type;
import org.hibernate.annotations.TypeDef;
import com.vladmihalcea.hibernate.type.json.JsonBinaryType;


import javax.persistence.*;
import java.time.Instant;

import static com.eragoo.transactionaloutbox.config.amqp.EventSender.EVENT_TYPE;

@TypeDef(
        name = "jsonb",
        typeClass = JsonBinaryType.class
)
@Entity
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class Outbox {
    private static final String GENERATOR = "action_generator";

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = GENERATOR)
    @SequenceGenerator(name = GENERATOR, sequenceName = "action_sequence")
    private Long id;

    @Type(type = "jsonb")
    @Column(columnDefinition = "jsonb")
    private String event;
    private Instant createdAt = Instant.now();
    private boolean processed = false;

    public Outbox(String event) {
        this.event = event;
    }
}
