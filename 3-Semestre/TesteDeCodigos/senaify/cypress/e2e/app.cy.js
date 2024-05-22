describe('template spec', () => {
  it('passes', () => {
    cy.visit('/')

    cy.viewport("iphone-xr")
  })

  it('Verifcar está exibido', () => {
    cy.get("[aria-label='title-head']")
    cy.get("[aria-label='title-head']").should("contain", "Good morning")
  })

  it('Verificar se tem uma lista com as playlists exibida', () => {
    cy.wait(2000)
    cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)
  })

  // it("Clicar em uma opção de playlist e listar suas músicas", () => {
  //   cy.get("[aria-label='playlist-item']").first().click()
  //   cy.wait(1000)

  //   cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)
  // })

  // it("Clicar em uma música e reproduzir o áudio", () => {
  //   cy.get("[aria-label='music-item']").eq(4).click()

  //   cy.scrollTo('top')
  // })

  it("Reproduzir a música da playlist escolhida", () => {
    cy.get("[aria-label='playlist-item']").contains("Top Brasil").click()
    // cy.wait(2000)

    cy.get("[aria-label='music-item']").contains("Casca de Bala").click()

    cy.scrollTo("top")
  })
})