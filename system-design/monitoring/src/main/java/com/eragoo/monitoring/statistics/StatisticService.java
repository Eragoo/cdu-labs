package com.eragoo.monitoring.statistics;

import com.eragoo.monitoring.ReverseLineInputStream;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.AllArgsConstructor;
import lombok.Getter;
import org.springframework.context.event.EventListener;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.annotation.PostConstruct;
import java.io.*;
import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.time.Instant;
import java.util.*;

@Service
@AllArgsConstructor
public class StatisticService {
    private final ObjectMapper objectMapper;

    //add several monitoring nodes in docker-compose.yml
    //todo split and save in backet per minute
    private final TreeSet<Statistic> eventsState = new TreeSet<>(Comparator.comparing(Statistic::getStartAtMinute));

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
                    eventsState.add(objectMapper.readValue(line, Statistic.class));
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
        Statistic lastStatisticRecord = eventsState.first();
        Instant timeNow = Instant.now();
        if (lastStatisticRecord.startAtMinute.plusMillis(1000 * 60).isAfter(timeNow)) {
            ++lastStatisticRecord.count;
            updateLastRecord(payments, lastStatisticRecord);
        } else {
            lastStatisticRecord = new Statistic(timeNow, 1L);
            eventsState.add(lastStatisticRecord);
            addNewRecord(payments, lastStatisticRecord);
        }


        objectMapper.writeValueAsString;

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

    //add at the end of file
    private void addNewRecord(File payments, Statistic lastStatisticRecord) {

    }

    //update last lone in the file
    //replace last line in the file java
    private void updateLastRecord(File payments, Statistic lastStatisticRecord) throws IOException {
        FileWriter fw = new FileWriter(payments);
        fw.append()
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

    @Getter
    @AllArgsConstructor
    public static class Statistic {
        Instant startAtMinute;
        long count;

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;

            Statistic statistic = (Statistic) o;

            if (count != statistic.count) return false;
            return startAtMinute.equals(statistic.startAtMinute);
        }

        @Override
        public int hashCode() {
            int result = startAtMinute.hashCode();
            result = 31 * result + (int) (count ^ (count >>> 32));
            return result;
        }
    }
}
