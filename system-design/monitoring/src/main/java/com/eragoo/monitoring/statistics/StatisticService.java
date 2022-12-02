package com.eragoo.monitoring.statistics;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.AllArgsConstructor;
import org.springframework.context.event.EventListener;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.annotation.PostConstruct;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.time.Instant;
import java.util.*;

@Service
@AllArgsConstructor
public class StatisticService {
    private final ObjectMapper objectMapper;
    private final TreeSet<PaymentCreatedEvent> eventsState = new TreeSet<>(Comparator.comparing(PaymentCreatedEvent::getCreatedAt));

    @PostConstruct
    public void init() {
        try {
            File file = new File("src/main/resources/currentState.json");
            if (!file.exists()) {
                file.createNewFile();
            }

            try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
                String line = reader.readLine();
                while (line != null) {
                    eventsState.add(objectMapper.readValue(line, PaymentCreatedEvent.class));
                    line = reader.readLine();
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @EventListener(PaymentCreatedEvent.class)
    public void onPaymentCreated(PaymentCreatedEvent event) throws JsonProcessingException {
        //save to file
        File payments = new File("payments.txt");
        objectMapper.writeValueAsString(event);

        try (FileWriter writer = new FileWriter(payments, true)) {
            writer.write(objectMapper.writeValueAsString(event));
            writer.append('\n');
            writer.flush();
        } catch (Exception e) {
            e.printStackTrace();
        }
        System.out.printf("Payment added: %s%n", event);
        eventsState.add(event);
    }


    public String getEventsState(String lookBack) {
        SortedSet<PaymentCreatedEvent> lastPayments = getLastPayments(lookBack);
        BigDecimal currentState = lastPayments.stream()
                .filter(PaymentCreatedEvent::isSuccess)
                .map(PaymentCreatedEvent::getAmount)
                .reduce(BigDecimal::add)
                .orElse(BigDecimal.ZERO);

        return new DecimalFormat("#.##").format(currentState.doubleValue() / 100d).replace(",", ".");
    }

    public SortedSet<PaymentCreatedEvent> getLastPayments(String lookBack) {
        //годинах (h), хвилинах (m), днях (d)
        String lookupType = lookBack.substring(lookBack.length() - 1, lookBack.length());
        int lookupValue = Integer.parseInt(lookBack.substring(0, lookBack.length() - 1));

        int minutesBefore = 0;

        if (lookupType.equals("h")) {
            minutesBefore = lookupValue * 60;
        } else if (lookupType.equals("d")) {
            minutesBefore = lookupValue * 60 * 24;
        } else if (lookupType.equals("m")) {
            minutesBefore = lookupValue;
        }

        Instant lookupFrom = Instant.now().minusSeconds(minutesBefore * 60);

        return eventsState.subSet(
                new PaymentCreatedEvent(-1L, BigDecimal.ONE, PaymentState.COMPLETE, lookupFrom),
                new PaymentCreatedEvent(-1L, BigDecimal.ONE, PaymentState.COMPLETE, Instant.now())
        );
    }
}
