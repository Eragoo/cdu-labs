package com.eragoo.monitoring.statistics;

import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/aggregations")
@Slf4j
@RequiredArgsConstructor
public class StatisticResource {
    public final StatisticService statisticService;

    @GetMapping("/money-received")
    public String currentState(
            String lookBack
    ) {
        return statisticService.getEventsState(lookBack);
    }
}
