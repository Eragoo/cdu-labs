package com.eragoo.transactionaloutbox.outbox;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;

@Repository
public interface OutboxRepository extends JpaRepository<Outbox, Long> {
    @Query("select o.id from Outbox o where o.processed = false order by o.createdAt")
    ArrayList<Long> findAllIdByProcessedIsFalseOrderByCreatedAt();
}
