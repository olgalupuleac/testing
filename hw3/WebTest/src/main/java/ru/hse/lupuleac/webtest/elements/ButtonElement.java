package ru.hse.lupuleac.webtest.elements;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class ButtonElement extends PageElement{
    public ButtonElement(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public void click() {
        webElement.click();
    }
}
