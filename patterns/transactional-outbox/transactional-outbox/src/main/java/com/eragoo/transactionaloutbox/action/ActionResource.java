package com.eragoo.transactionaloutbox.action;

import lombok.Getter;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Set;

@RestController
@RequestMapping("/actions")
@Slf4j
@RequiredArgsConstructor
public class ActionResource {
    public final ActionService actionService;

    @PostMapping
    public void createDummyAction() {
        actionService.create();
    }

    @GetMapping
    public Set<ActionDto> getAll() {
        return actionService.getAll();
    }
}
